            using (FileStream fileStream = new FileStream("filename", FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader streamReader = new StreamReader(fileStream))
                {
                    while (streamReader.Peek() > -1)
                    {
                        string line = streamReader.ReadLine();
                        string[] parts = line.Split('\t');
                        outputs[lineCounter] = int.Parse(parts[0]);
                        inputs[lineCounter] = new int[4];
                        inputs[lineCounter][0] = int.Parse(parts[1]);
                        inputs[lineCounter][1] = int.Parse(parts[2]);
                        inputs[lineCounter][2] = int.Parse(parts[3]);
                        inputs[lineCounter][3] = int.Parse(parts[4]);
                        lineCounter++;
                    }
                }
            }
