                System.IO.Stream input = context.Assets.Open(FILENAME);
                Java.IO.FileOutputStream output = new Java.IO.FileOutputStream(file);
                byte[] buffer = new byte[1024];
                int size;
                while ((size = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    output.Write(buffer, 0, size);
                }
                input.Close();
                output.Close();
