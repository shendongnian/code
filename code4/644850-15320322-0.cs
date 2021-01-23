     public struct Transfer_packet 
            {
                public short  _packet_type; // 0 is action 1 is data
                public int _packet_len; // length of data
                public byte[] _data;//Content of data it's Length depends on objects types 
               
                public byte[] serialize()
                {
                    byte[] arr;
                    MemoryStream ms = new MemoryStream();
                    arr = BitConverter.GetBytes(this._packet_type);
                   // Array.Reverse(arr);
                    ms.Write(arr, 0, arr.Length);
                    arr = BitConverter.GetBytes(this._packet_len);
                   // Array.Reverse(arr);
                    ms.Write(arr,0,arr.Length);
                    ms.Write(this._data, 0, this._data.Length);
                    arr = ms.ToArray();
                   return arr;
                }
            }
