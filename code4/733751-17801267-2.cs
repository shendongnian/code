    //Single Threaded          : 1701, 1825, 1495, 1606
    //Multi Threaded           : 1516, 1446, 1581, 1401
    //Struct Single Threaded   :  154,  157,  153,  151
    //Struct MultiThreaded     :  104,  107,  106,  103
    
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Threading.Tasks;
    
    namespace ConsoleApplication3
    {
        class Program
        {
            static void Main(string[] args)
            {
                while (true)
                {
                    Benchmark("Single Threaded", () => CreateCells(1, 1, 0, 0));
                    Benchmark("Multi Threaded", () => CreateCellsThreaded(1, 1, 0, 0));
                    Benchmark("Struct Single Threaded", () => CreateStructCells(1, 1, 0, 0));
                    Benchmark("Struct MultiThreaded", () => CreateStructCellsThreaded(1, 1, 0, 0));
                }
            }
    
            static void Benchmark(string Name, Action test)
            {
                var sw = Stopwatch.StartNew();
                test();
                UpdateResults(Name, sw.ElapsedMilliseconds.ToString());
                GC.Collect();
            }
    
            static Dictionary<string, string> results = new Dictionary<string, string>();
            static void UpdateResults(string key, string value)
            {
                value = value.PadLeft(4);
                if (results.ContainsKey(key))
                    results[key] += ", " + value;
                else
                    results[key] = value;
    
                Console.Clear();
                foreach (var kvp in results) Console.WriteLine(kvp.Key.PadRight(25) + ": " + kvp.Value);
            }
    
            const int RowsCount = 2600;
            const int ColumnsCount = 2600;
    
            public class Point
            {
                public int x;
                public int y;
                public Point(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }
            }
    
            public class GridCell
            {
                public int width;
                public int height;
                public Point point;
                public GridCell(int width, int height, Point point)
                {
                    this.width = width;
                    this.height = height;
                    this.point = point;
                }
            }
    
            public struct StructPoint
            {
                public int x;
                public int y;
                public StructPoint(int x, int y)
                {
                    this.x = x;
                    this.y = y;
                }
            }
    
    
            public struct StructGridCell
            {
                public int width;
                public int height;
                public StructPoint point;
                public StructGridCell(int width, int height, StructPoint point)
                {
                    this.width = width;
                    this.height = height;
                    this.point = point;
                }
            }
    
            private static void CreateCells(int cellWidth, int cellHeight, int startX, int startY)
            {
                var Cells = new GridCell[RowsCount][];
                for (int i = 0; i < RowsCount; i++)
                {
                    Cells[i] = new GridCell[ColumnsCount];
                    for (int j = 0; j < ColumnsCount; j++)
                    {
                        Point coordinate = new Point(startX + cellWidth * j, startY + cellHeight * i);
                        Cells[i][j] = new GridCell(cellWidth, cellHeight, coordinate);
                    }
                }
            }
            private static void CreateCellsThreaded(int cellWidth, int cellHeight, int startX, int startY)
            {
                var Cells = new GridCell[RowsCount][];
                Parallel.For(0, RowsCount, new ParallelOptions { MaxDegreeOfParallelism = 4 }, i =>
                {
                    Cells[i] = new GridCell[ColumnsCount];
                    for (int j = 0; j < ColumnsCount; j++)
                    {
                        Point coordinate = new Point(startX + cellWidth * j, startY + cellHeight * i);
                        Cells[i][j] = new GridCell(cellWidth, cellHeight, coordinate);
                    }
                });
            }
    
            private static void CreateStructCells(int cellWidth, int cellHeight, int startX, int startY)
            {
                var Cells = new StructGridCell[RowsCount][];
                for (int i = 0; i < RowsCount; i++)
                {
                    Cells[i] = new StructGridCell[ColumnsCount];
                    for (int j = 0; j < ColumnsCount; j++)
                    {
                        var coordinate = new StructPoint(startX + cellWidth * j, startY + cellHeight * i);
                        Cells[i][j] = new StructGridCell(cellWidth, cellHeight, coordinate);
                    }
                }
            }
            private static void CreateStructCellsThreaded(int cellWidth, int cellHeight, int startX, int startY)
            {
                var Cells = new StructGridCell[RowsCount][];
                Parallel.For(0, RowsCount, i =>
                {
                    Cells[i] = new StructGridCell[ColumnsCount];
                    for (int j = 0; j < ColumnsCount; j++)
                    {
                        var coordinate = new StructPoint(startX + cellWidth * j, startY + cellHeight * i);
                        Cells[i][j] = new StructGridCell(cellWidth, cellHeight, coordinate);
                    }
                });
            }
        }
    }
