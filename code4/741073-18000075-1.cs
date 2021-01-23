    using System.Collections.Generic;
    using System.Linq;
    using LinqLib.Array;
    
    ...
        public void TakeEm(IEnumerable<int> data)
        {
            var dataAry = data as int[] ?? data.ToArray();
            var rows = (dataAry.Length/3) + 1;
            //var columns = Enumerable.Empty<int>().ToArray(3, rows);
            // vvv These two lines are the ones that re-arrange your array
            var columns = dataAry.ToArray(3, rows);
            var menus = columns.Slice();
        }
