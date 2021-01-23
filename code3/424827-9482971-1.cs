		static SecStatusCode SetID (Guid setID)
		{
			SecRecord queryRec = new SecRecord (SecKind.GenericPassword) { 
				Service = "KEYCHAIN_SERVICE", 
				Label = "KEYCHAIN_SERVICE", 
				Account = "KEYCHAIN_ACCOUNT" 
			};
			var record = new SecRecord (SecKind.GenericPassword) {
				Service = "KEYCHAIN_SERVICE",
				Label = "KEYCHAIN_SERVICE",
				Account = "KEYCHAIN_ACCOUNT",
				Generic = NSData.FromString (Convert.ToString (setID), NSStringEncoding.UTF8),
				Accessible = SecAccessible.Always
			};
			SecStatusCode code = SecKeyChain.Add (record);
			if (code == SecStatusCode.DuplicateItem) {
				code = SecKeyChain.Remove (queryRec);
				if (code == SecStatusCode.Success)
					code = SecKeyChain.Add (record);
			}
			return code;
		}
