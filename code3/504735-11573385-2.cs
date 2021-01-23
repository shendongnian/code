    using System;
    using System.Diagnostics;
    using System.Threading.Tasks;
    namespace TextureFromPoints
    {
        class RevisedProgram
        {
            const int numPoints = 700;
            const int textureSize = 1024;
            static Random rnd = new Random();
            static void Main(string[] args)
            {
                while(true)
                {
                    Console.WriteLine("Starting REVISED");
                    Console.WriteLine();
                    var pointCloud = new Vector3[numPoints];
                    for(int i = 0; i < numPoints; i++)
                        pointCloud[i] = new Vector3(textureSize);
                    var result1 = new Vector3[textureSize, textureSize];
                    var result2 = new Vector3[textureSize, textureSize];
                    var result3 = new Vector3[textureSize, textureSize];
                    var sw1 = Inline(pointCloud, result1);
                    var sw2 = NotInline(pointCloud, result2);
                    var sw3 = Parallelized(pointCloud, result3);
                    Console.WriteLine("Completed {0}x{0} pixels with {1} points in...", textureSize, numPoints);
                    Console.WriteLine("{0}: {1}ms", "For Loop (Inline)", sw1.ElapsedMilliseconds);
                    Console.WriteLine("{0}: {1}ms", "For Loop", sw2.ElapsedMilliseconds);
                    Console.WriteLine("{0}: {1}ms", "Parallel.For Loop", sw3.ElapsedMilliseconds);
                    Console.WriteLine();
                    Console.Write("Verifying Data: ");
                    Console.WriteLine(CheckResults(result1, result2) && CheckResults(result1, result3) ? "Valid" : "Error");
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.ReadLine();
                }
            }
            private static Stopwatch Parallelized(Vector3[] pointCloud, Vector3[,] result3)
            {
                var sw3 = Stopwatch.StartNew();
                Parallel.For(0, textureSize, x =>
                {
                    for(int y = 0; y < textureSize; y++)
                        Computation(pointCloud, result3, x, y);
                });
                sw3.Stop();
                return sw3;
            }
            private static Stopwatch NotInline(Vector3[] pointCloud, Vector3[,] result2)
            {
                var sw2 = Stopwatch.StartNew();
                for(int x = 0; x < textureSize; x++)
                    for(int y = 0; y < textureSize; y++)
                        Computation(pointCloud, result2, x, y);
                sw2.Stop();
                return sw2;
            }
            private static Stopwatch Inline(Vector3[] pointCloud, Vector3[,] result1)
            {
                var sw1 = Stopwatch.StartNew();
                for(int x = 0; x < textureSize; x++)
                    for(int y = 0; y < textureSize; y++)
                    {
                        var targetPos = new Vector3(x, y, 0);
                        var nearestV3 = pointCloud[0];
                        Vector3 temp1 = nearestV3 - targetPos;
                        var nearestV3Distance = temp1.x * temp1.x + temp1.y * temp1.y + temp1.z * temp1.z;
                        for(int i = 1; i < numPoints; i++)
                        {
                            var currentV3 = pointCloud[i];
                            Vector3 temp2 = currentV3 - targetPos;
                            var currentV3Distance = temp2.x * temp2.x + temp2.y * temp2.y + temp2.z * temp2.z;
                            if(currentV3Distance < nearestV3Distance)
                            {
                                nearestV3 = currentV3;
                                nearestV3Distance = currentV3Distance;
                            }
                        }
                        result1[x, y] = nearestV3;
                    }
                sw1.Stop();
                return sw1;
            }
            private static bool CheckResults(Vector3[,] lhs, Vector3[,] rhs)
            {
                for(int x = 0; x < textureSize; x++)
                    for(int y = 0; y < textureSize; y++)
                        if(!lhs[x, y].Equals(rhs[x, y]))
                            return false;
                return true;
            }
            private static void Computation(Vector3[] pointCloud, Vector3[,] result, int x, int y)
            {
                var targetPos = new Vector3(x, y, 0);
                var nearestV3 = pointCloud[0];
                Vector3 temp1 = nearestV3 - targetPos;
                var nearestV3Distance = temp1.x * temp1.x + temp1.y * temp1.y + temp1.z * temp1.z;
                for(int i = 1; i < numPoints; i++)
                {
                    var currentV3 = pointCloud[i];
                    Vector3 temp2 = currentV3 - targetPos;
                    var currentV3Distance = temp2.x * temp2.x + temp2.y * temp2.y + temp2.z * temp2.z;
                    if(currentV3Distance < nearestV3Distance)
                    {
                        nearestV3 = currentV3;
                        nearestV3Distance = currentV3Distance;
                    }
                }
                result[x, y] = nearestV3;
            }
            private static float DistanceToPoint(Vector3 vector, Vector3 point)
            {
                Vector3 final = vector - point;
                return final.x * final.x + final.y * final.y + final.z * final.z;
            }
            struct Vector3
            {
                public float x;
                public float y;
                public float z;
                public Vector3(float x, float y, float z)
                {
                    this.x = x;
                    this.y = y;
                    this.z = z;
                }
                public Vector3(float randomDistance)
                {
                    this.x = (float)rnd.NextDouble() * randomDistance;
                    this.y = (float)rnd.NextDouble() * randomDistance;
                    this.z = (float)rnd.NextDouble() * randomDistance;
                }
                public static Vector3 operator -(Vector3 a, Vector3 b)
                {
                    return new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
                }
            }
        }
    }
