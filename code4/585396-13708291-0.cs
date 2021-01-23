            JObject o = JObject.Parse(json);
            if (o != null)
            {
                var test = o.First;
                if (test != null)
                {
                    var test2 = test.First;
                    if (test2 != null)
                    {
                        DiskSpaceInfo[] diskSpaceArray = test2.ToObject<DiskSpaceInfo[]>();
                    }
                }
            }
