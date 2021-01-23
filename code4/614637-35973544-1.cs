    private static void LogWithCallerSiteInfo(string format, object[] args, string callerMemberName, string callerFilePath, int callerLineNumber, Action<string, object[]> logRequest)
		{
			if (args == null)
			{
				args = new object[0];
			}
			var args2 = new object[args.Length + 3];
			args.CopyTo(args2, 0);
			args2[args.Length] = sourceFile;
			args2[args.Length + 1] = memberName;
			args2[args.Length + 2] = lineNumber;
			logRequest(format + " [{callerFilePath:l}.{callerMemberName:l}-{callerLineNumber}]", args2);
		}
