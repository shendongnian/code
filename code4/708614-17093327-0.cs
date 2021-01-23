		private void button1_Click(object sender, EventArgs e)
			{
            this.Hide();
            Thread t = new Thread(new ParameterizedThreadStart(RunInternalExe));
            t.Start("RunCodeFromDll.exe");
            //RunInternalExe("RunCodeFromDll.exe");
			}
		static void RunInternalExe(object tempName)
			{
            string exeName = tempName.ToString();
            //Get the current assembly
            Assembly assembly = Assembly.GetExecutingAssembly();
            //Get the assembly's root name
            string rootName = assembly.GetName().Name;
            //Get the resource stream
            Stream resourceStream = assembly.GetManifestResourceStream(rootName + "." + exeName);
            //Verify the internal exe exists
            if (resourceStream == null)
                return;
            //Read the raw bytes of the resource
            byte[] resourcesBuffer = new byte[resourceStream.Length];
            resourceStream.Read(resourcesBuffer, 0, resourcesBuffer.Length);
            resourceStream.Close();
            //Load the bytes as an assembly
            Assembly exeAssembly = Assembly.Load(resourcesBuffer);
            //Execute the assembly
            exeAssembly.EntryPoint.Invoke(null, null); //.EntryPoint.Invoke(null, null); //no parameters
			}
