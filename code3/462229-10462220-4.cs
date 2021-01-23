    using System;
    using System.Collections.Generic;
    
    namespace TetrahedronVertices
    {
        class Program
        {
            static void Main()
            {
                // Size parameter: This is distance of each vector from origin
                var r = 1d;
    
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
                var phi = (float) (Math.Sqrt(5) - 1) / 2; // The golden ratio
                var R = (float) (r / Math.Sqrt(3));
    
                var a = (R * 1);
                var b = R / phi;
                var c = R * phi;
    
                // Generate each vertex
                var vertices = new List<Vertex>();
                for (var i = -1; i < 2; i += 2)
                {
                    for (var j = -1; j < 2; j += 2)
                    {
                        vertices.Add(new Vertex(
                                            0,
                                            i * c * R,
                                            j * b * R));
                        vertices.Add(new Vertex(
                                            i * c * R,
                                            j * b * R,
                                            0));
                        vertices.Add(new Vertex(
                                            i * b * R,
                                            0,
                                            j * c * R));
    
                        for (var k = -1; k < 2; k += 2)
                            vertices.Add(new Vertex(
                                                i * a * R,
                                                j * a * R,
                                                k * a * R));
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
            float x;
            float y;
            float z;
    
            public Vertex(float x, float y, float z)
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
