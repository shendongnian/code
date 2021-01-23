    	/// <summary>
	/// This flag enables the user to use the mouse to select and edit text. To enable
	/// this option, you must also set the ExtendedFlags flag.
	/// </summary>
	const int QuickEditMode = 64;
	// ExtendedFlags must be combined with
	// InsertMode and QuickEditMode when setting
	/// <summary>
	/// ExtendedFlags must be enabled in order to enable InsertMode or QuickEditMode.
	/// </summary>
	const int ExtendedFlags = 128;
	BOOLEAN EnableQuickEdit()
	{
		HWND conHandle = GetStdHandle(STD_INPUT_HANDLE);
		int mode;
		DWORD dwLastError = GetLastError();
		if (!GetConsoleMode(conHandle, &mode))
		{
			// error getting the console mode. Exit.
			dwLastError = GetLastError();
			return (dwLastError == 0);
		}
		else 
			dwLastError = 0;
		mode = mode & ~QuickEditMode;
		if (!SetConsoleMode(conHandle, mode | ExtendedFlags))
		{
			// error setting console mode.
			dwLastError = GetLastError();
		}
		else
			dwLastError = 0;
		return (dwLastError == 0);
	}
	BOOLEAN DisableQuickEdit()
	{
		HWND conHandle = GetStdHandle(STD_INPUT_HANDLE);
		int mode;
		DWORD dwLastError = GetLastError();
		if (!GetConsoleMode(conHandle, &mode))
		{
			// error getting the console mode. Exit.
			dwLastError = GetLastError();
			return (dwLastError == 0);
		}
		else
			dwLastError = 0;
		mode = mode | QuickEditMode;
		if (!SetConsoleMode(conHandle, mode))
		{
			// error getting the console mode. Exit.
			dwLastError = GetLastError();
		}
		else
			dwLastError = 0;
		return (dwLastError == 0);
	}
