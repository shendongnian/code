        void SimpleSerialize(Stream stream, Test[] arr)
        {
            foreach (var obj in arr)
            {
                var bytes = BitConverter.GetBytes(obj.A);
                stream.Write(bytes, 0, bytes.Length);
            }
        }
