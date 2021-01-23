		/// <summary>
		/// Registers a file type. This enables users to open a file via double-clicking in the windows explorer. 
		/// ATTENTION: Providing a wrong extension or fileType will certainly cause a malfunction of other file types!!!
		/// </summary>
		/// <param name="extension"> The file extension (this may contain a starting '.') </param>
		/// <param name="fileType"> Name of the file type. </param>
		/// <param name="fileDescription"> Descriptive text for the file type. Displayed in the windows explorer. </param>
		/// <param name="verb"> Verb to use, usually 'open' </param>
		/// <param name="commandLine"> Commandline for the 'open' verb. Example: "C:\Zeiss\CmmCtrl\bin\ScriptTool.exe %1". You may use quotes ("") if any argument contains whitespaces. Don't forget to use a %1, which is replaced  </param>
		public static void RegisterFileType(string extension, string fileType, string fileDescription, string verb, string commandLine) {
			RegisterFileType(extension, fileType, fileDescription, verb, commandLine, "", -1);
		}
		/// <summary>
		/// Registers a file type. This enables users to open a file via double-clicking in the windows explorer. 
		/// ATTENTION: Providing a wrong extension or fileType will certainly cause a malfunction of other file types!!!
		/// </summary>
		/// <param name="extension"> The file extension (this may contain a starting '.') </param>
		/// <param name="fileType"> Name of the file type. </param>
		/// <param name="fileDescription"> Descriptive text for the file type. Displayed in the windows explorer. </param>
		/// <param name="verb"> Verb to use, usually 'open' </param>
		/// <param name="programPath"> Full path to the program to open the file. You may use quotes ("") if any argument contains whitespaces. Example: "C:\Zeiss\CmmCtrl\bin\ScriptTool.exe" </param>
		/// <param name="arguments"> Commandline for the 'open' verb. Don't forget to use a "%1". You may use quotes ("") if any argument contains whitespaces. Example: "%1"</param>
		/// <param name="iconIndex"> Index of the icon within the executable. Use -1 if not used. </param>
		public static void RegisterFileType(string extension, string fileType, string fileDescription, string verb, string programPath, string arguments, int iconIndex) {
			if (!extension.StartsWith(".")) extension = "." + extension;
			RegistryKey key;
			string commandLine = programPath + " " + arguments;
			// 1) Extension
			//    HKEY_CLASSES_ROOT\.zzz=zzzFile
			key = Registry.ClassesRoot.CreateSubKey(extension);
			key.SetValue("", fileType);
			key.Flush();
			// 2) File type
			//    HKEY_CLASSES_ROOT\zzzFile=ZZZ File
			key = Registry.ClassesRoot.CreateSubKey(fileType);
			key.SetValue("", fileDescription);
			key.Flush();
			// 3) Action (verb)
			//    HKEY_CLASSES_ROOT\zzzFile\shell\open\command=Notepad.exe %1
			//    HKEY_CLASSES_ROOT\zzzFile\shell\print\command=Notepad.exe /P %1
			key = Registry.ClassesRoot.CreateSubKey(fileType + "\\shell\\" + verb + "\\command");
			key.SetValue("", commandLine);
			key.Flush();
			// 4) Icon
			if (iconIndex >= 0) {
				key = Registry.ClassesRoot.CreateSubKey(fileType + "\\DefaultIcon");
				key.SetValue("", programPath + "," + iconIndex.ToString());
				key.Flush();
			}
			// 5) Notify running applications
			SHChangeNotify(SHChangeNotifyEventID.SHCNE_ASSOCCHANGED, SHChangeNotifyFlags.SHCNF_IDLIST, IntPtr.Zero, IntPtr.Zero);
		}
		/// <summary> Notifies the system of an event that an application has performed. An application should use this function if it performs an action that may affect the Shell. </summary>
		[DllImport("shell32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		public static extern void SHChangeNotify(SHChangeNotifyEventID wEventId, SHChangeNotifyFlags uFlags, IntPtr dwItem1, IntPtr dwItem2);
