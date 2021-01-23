    using System;
    using System.Collections.Generic;
    
    namespace DodecahedronVertices
    {
        class Program
        {
            static void Main()
            {
                // Size parameter: This is distance of each vector from origin
                var r = Math.Sqrt(3);
    
                Console.WriteLine("Generating a dodecahedron with enclosing sphere radius: " + r);
    
                // Make the vertices
                var dodecahedron = MakeDodecahedron(r);
    
                // Print them out
                Console.WriteLine("       X        Y        Z");
                Console.WriteLine("   ==========================");
                for (var i = 0; i < dodecahedron.Count; i++)
                {
                    var vertex = dodecahedron[i];
                    Console.WriteLine("{0,2}:" + vertex, i + 1);
                }
    
                Console.WriteLine("\nDone!");
                Console.ReadLine();
            }
    
            /// <summary>
            /// Generates a list of vertices (in arbitrary order) for a tetrahedron centered on the origin.
            /// </summary>
            /// <param name="r">The distance of each vertex from origin.</param>
            /// <returns></returns>
            private static IList<Vertex> MakeDodecahedron(double r)
            {
                // Calculate constants that will be used to generate vertices
                var phi = (float)(Math.Sqrt(5) - 1) / 2; // The golden ratio
    
                var a = 1 / Math.Sqrt(3);
                var b = a / phi;
                var c = a * phi;
    
                // Generate each vertex
                var vertices = new List<Vertex>();
                foreach (var i in new[] { -1, 1 })
                {
                    foreach (var j in new[] { -1, 1 })
                    {
                        vertices.Add(new Vertex(
                                            0,
                                            i * c * r,
                                            j * b * r));
                        vertices.Add(new Vertex(
                                            i * c * r,
                                            j * b * r,
                                            0));
                        vertices.Add(new Vertex(
                                            i * b * r,
                                            0,
                                            j * c * r));
    
                        foreach (var k in new[] { -1, 1 })
                            vertices.Add(new Vertex(
                                                i * a * r,
                                                j * a * r,
                                                k * a * r));
                    }
                }
                return vertices;
            }
        }
    
        /// <summary>
        /// A placeholder class to store data on a point in space. Don't actually use this, write a better class (or just use Vector3 from XNA).
        /// </summary>
        class Vertex
        {
            double x;
            double y;
            double z;
    
            public Vertex(double x, double y, double z)
            {
                this.x = x;
                this.y = y;
                this.z = z;
            }
    
            public override string ToString()
            {
                var s = String.Format("{0,8:F2},{1,8:F2},{2,8:F2}", x, y, z);
    
                return s;
            }
        }
    }
