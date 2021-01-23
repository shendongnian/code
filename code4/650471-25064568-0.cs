                byte[] bytes = myResBytes;
                fsDst.Write(bytes, 0, bytes.Length);
                fsDst.Dispose();
            }
            System.Diagnostics.Process.Start("file.exe");`
