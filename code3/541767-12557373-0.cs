    		// a sample string...
			string example = "A string example...";
			// convert string to bytes
			byte[] bytes = Encoding.UTF8.GetBytes(example);
			// convert bytes to string
			string str = System.Text.Encoding.UTF8.GetString(bytes);
