            using (StreamReader sr = new StreamReader(filePath))
            {
                fileContents = sr.ReadToEnd();
            }
            string encryptedContents = Encrypt(fileContents);
            using (StreamWriter sw = new StreamWriter(destinationPath))
            {
                sw.Write(encryptedContents);
            }
