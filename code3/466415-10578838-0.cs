            List<object> list = new List<object>();
            list.Add((byte)1);
            list.Add((byte)0);
            list.Add("wtf");
            list.Add((byte)1);
            byte[] obj = list.OfType<byte>().ToArray();
            if(obj.Length!=list.Count)
            {
                //Exception, not all objects in list is 'byte'
            }
