            unsafe
            {
                var w = new StreamWriter(@".\test.txt");
                for (int i = 0; i < count; i++)
                {
                    var handle = GCHandle.Alloc(smallBlocks[i], GCHandleType.Pinned);
                    w.WriteLine(String.Format("{0,10}\t{1,10}", i, handle.AddrOfPinnedObject()));
                    handle.Free();
                }
                w.Close();
            }
