    public static IpcServerChannel IpcCreateServer<TRemoteObject>(
            ref String RefChannelName,
            WellKnownObjectMode InObjectMode,
            TRemoteObject ipcInterface, String ipcUri, bool useNewMethod,
            params WellKnownSidType[] InAllowedClientSIDs) where TRemoteObject : MarshalByRefObject
        {
            String ChannelName = RefChannelName ?? GenerateName();
            ///////////////////////////////////////////////////////////////////
            // create security descriptor for IpcChannel...
            System.Collections.IDictionary Properties = new System.Collections.Hashtable();
            Properties["name"] = ChannelName;
            Properties["portName"] = ChannelName;
            DiscretionaryAcl DACL = new DiscretionaryAcl(false, false, 1);
            if (InAllowedClientSIDs.Length == 0)
            {
                if (RefChannelName != null)
                    throw new System.Security.HostProtectionException("If no random channel name is being used, you shall specify all allowed SIDs.");
                // allow access from all users... Channel is protected by random path name!
                DACL.AddAccess(
                    AccessControlType.Allow,
                    new SecurityIdentifier(
                        WellKnownSidType.WorldSid,
                        null),
                    -1,
                    InheritanceFlags.None,
                    PropagationFlags.None);
            }
            else
            {
                for (int i = 0; i < InAllowedClientSIDs.Length; i++)
                {
                    DACL.AddAccess(
                        AccessControlType.Allow,
                        new SecurityIdentifier(
                            InAllowedClientSIDs[i],
                            null),
                        -1,
                        InheritanceFlags.None,
                        PropagationFlags.None);
                }
            }
            CommonSecurityDescriptor SecDescr = new CommonSecurityDescriptor(false, false,
                ControlFlags.GroupDefaulted |
                ControlFlags.OwnerDefaulted |
                ControlFlags.DiscretionaryAclPresent,
                null, null, null,
                DACL);
            //////////////////////////////////////////////////////////
            // create IpcChannel...
            BinaryServerFormatterSinkProvider BinaryProv = new BinaryServerFormatterSinkProvider();
            BinaryProv.TypeFilterLevel = TypeFilterLevel.Full;
            IpcServerChannel Result = new IpcServerChannel(Properties, BinaryProv, SecDescr);
            if (!useNewMethod)
            {
                ChannelServices.RegisterChannel(Result, false);
                RemotingConfiguration.RegisterWellKnownServiceType(
                    typeof(TRemoteObject),
                    ChannelName,
                    InObjectMode);
            }
            else
            {
                ChannelServices.RegisterChannel(Result, false);
                ObjRef refGreeter = RemotingServices.Marshal(ipcInterface, ipcUri);
            }
            RefChannelName = ChannelName;
            return Result;
        }
        /// <summary>
        /// Creates a globally reachable, managed IPC-Port.
        /// </summary>
        /// <remarks>
        /// Because it is something tricky to get a port working for any constellation of
        /// target processes, I decided to write a proper wrapper method. Just keep the returned
        /// <see cref="IpcChannel"/> alive, by adding it to a global list or static variable,
        /// as long as you want to have the IPC port open.
        /// </remarks>
        /// <typeparam name="TRemoteObject">
        /// A class derived from <see cref="MarshalByRefObject"/> which provides the
        /// method implementations this server should expose.
        /// </typeparam>
        /// <param name="InObjectMode">
        /// <see cref="WellKnownObjectMode.SingleCall"/> if you want to handle each call in an new
        /// object instance, <see cref="WellKnownObjectMode.Singleton"/> otherwise. The latter will implicitly
        /// allow you to use "static" remote variables.
        /// </param>
        /// <param name="RefChannelName">
        /// Either <c>null</c> to let the method generate a random channel name to be passed to 
        /// <see cref="IpcConnectClient{TRemoteObject}"/> or a predefined one. If you pass a value unequal to 
        /// <c>null</c>, you shall also specify all SIDs that are allowed to connect to your channel!
        /// </param>
        /// <param name="InAllowedClientSIDs">
        /// If no SID is specified, all authenticated users will be allowed to access the server
        /// channel by default. You must specify an SID if <paramref name="RefChannelName"/> is unequal to <c>null</c>.
        /// </param>
        /// <returns>
        /// An <see cref="IpcChannel"/> that shall be keept alive until the server is not needed anymore.
        /// </returns>
        /// <exception cref="System.Security.HostProtectionException">
        /// If a predefined channel name is being used, you are required to specify a list of well known SIDs
        /// which are allowed to access the newly created server.
        /// </exception>
        /// <exception cref="RemotingException">
        /// The given channel name is already in use.
        /// </exception>
        public static IpcServerChannel IpcCreateServer<TRemoteObject>(
            ref String RefChannelName,
            WellKnownObjectMode InObjectMode,
            params WellKnownSidType[] InAllowedClientSIDs) where TRemoteObject : MarshalByRefObject
        {
            return IpcCreateServer<TRemoteObject>(ref RefChannelName, InObjectMode, null, null, false, InAllowedClientSIDs);
        }
