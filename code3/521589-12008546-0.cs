        public static pawobject[] operator +(pawobject A, pawobject B)
        {
            pawobject[] Result = new pawobject[2];
            Result[0] = A;
            Result[1] = B;
            return Result;
        }
        public static pawobject[] operator +(pawobject[] Array, pawobject B)
        {
            Array.Resize<pawojbect>(ref Array, Array.Length +1);
            Array[Array.Length -1] = B;
        }
