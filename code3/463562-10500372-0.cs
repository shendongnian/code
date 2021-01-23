    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    
    
    unsafe class Program
    {
        static void Main(string[] args)
        {
            Link[] arr = new Link[] { 
                new Link(1),
                new Link(2),
                new Link(3),
                new Link(4),
            };
    
            fixed (Link* pLinks = arr) // for demo purposes create a node instance
            {
                var nde = new Node
                {
                    LinkCount = arr.Length,
                    Links = new IntPtr(pLinks) // Marshal as IntPtr is safe, later the data can be retrieved via an Extension method.
                };
    
                foreach (var link in nde.GetLinks())
                {
                    Console.WriteLine("Link {0}", link.I);
                }
            };
        }
    }
    
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct Link
    {
        // some primitive data (2 integers for example)
        public int I;
    
        public Link(int i)
        {
            I = i;
        }
    }
    
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    public unsafe struct Node
    {
        [FieldOffset(0)]
        public int LinkCount;
        [FieldOffset(4)]
        public IntPtr Links; // this assumes that the Links is some unsafe buffer which is not under GC control or it is pinned
    }
    
    
    static class LinkExtensions
    {
        public static IEnumerable<Link> GetLinks(this Node node)
        {
            for (int i = 0; i < node.LinkCount; i++) // very efficient if you want to traverse millions of nodes without marshalling all of them at once
            {
                // alternatively you can also use a memcpy (PInvoke to msvcrt.dll) to fill in the data from a given offset.
                // it is up to you to decide which is faster
                yield return (Link)Marshal.PtrToStructure(node.Links + IntPtr.Size * i, typeof(Link));
            }
        }
    }
