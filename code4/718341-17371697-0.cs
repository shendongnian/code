    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.InteropServices;
    public static List<Point> GetPointsOnLine(Point point1, Point point2)
    {
        var points = new List<Point>();
        var handle = GCHandle.Alloc(points);
        try
        {
            LineDDA(point1.X, point1.Y, point2.X, point2.Y, GetPointsOnLineCallback, GCHandle.ToIntPtr(handle));
        }
        finally
        {
            handle.Free();
        }
        return points;
    }
    private static void GetPointsOnLineCallback(int x, int y, IntPtr lpData)
    {
        var handle = GCHandle.FromIntPtr(lpData);
        var points = (List<Point>) handle.Target;
        points.Add(new Point(x, y));
    }
    [DllImport("gdi32.dll")]
    private static extern bool LineDDA(int nXStart, int nYStart, int nXEnd, int nYEnd, LineDDAProc lpLineFunc, IntPtr lpData);
    // The signature for the callback method
    private delegate void LineDDAProc(int x, int y, IntPtr lpData);
