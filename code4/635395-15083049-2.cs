    // In a static class:
    public static void Dispose(this IEnumerable<IDisposable> e) {
        foreach(var x in e) {
            x.Dispose();
        }
    }
    // Somewhere else:
    List<Bitmap> l = new List<Bitmap>();
    l.Dispose();
