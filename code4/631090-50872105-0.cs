        /// <returns>totalAvailable, inUseCount, idleCount</returns>
        public int[] GetPoolStatsViaReflection(MySqlConnectionStringBuilder connectionStringBuilder)
        {
            var asm = typeof(MySqlConnectionStringBuilder).Assembly;
            var poolManagerType = asm.GetType("MySql.Data.MySqlClient.MySqlPoolManager"); // internal sealed
            var poolType = asm.GetType("MySql.Data.MySqlClient.MySqlPool"); // internal sealed
            var pool = poolManagerType.InvokeMember("GetPool", System.Reflection.BindingFlags.InvokeMethod | System.Reflection.BindingFlags.Static | System.Reflection.BindingFlags.Public, null, null, new object[] { connectionStringBuilder });
            const System.Reflection.BindingFlags nonPublicInstanceField = System.Reflection.BindingFlags.GetField | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance;
            var totalAvailable = (int)poolType.InvokeMember("available", nonPublicInstanceField, null, pool, new object[] { });
            // List<Driver>
            var inUsePool = (System.Collections.ICollection)poolType.InvokeMember("inUsePool", nonPublicInstanceField, null, pool, new object[] { });
            // Queue<Driver>
            var idlePool = (System.Collections.ICollection)poolType.InvokeMember("idlePool", nonPublicInstanceField, null, pool, new object[] { });
            return new[] {totalAvailable, inUsePool.Count, idlePool.Count};
        }
