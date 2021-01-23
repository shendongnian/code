                var maxGuid = Guid.Empty;
                var maxDateTime = DateTime.MinValue;
                foreach (var kvp in d)
                {
                    if (kvp.Value > maxDateTime)
                    {
                        maxGuid = kvp.Key;
                        maxDateTime = kvp.Value;
                    }
                }
                Console.WriteLine("Guid of max date is: " + maxGuid.ToString());
