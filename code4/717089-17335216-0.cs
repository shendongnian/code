    // create a file at this location
    var fileName = @"E:\Temp\attr.txt";
    var fi = new FileInfo(fileName);
    Console.WriteLine("Attributes: {0}", fi.Attributes); // Archive
    var fi2 = new FileInfo(fileName);
    fi2.Attributes = fi2.Attributes | FileAttributes.ReadOnly;
    Console.WriteLine("New Attributes: {0}", fi2.Attributes); // Archive, ReadOnly
    Console.WriteLine("Stale attributes: {0}", fi.Attributes); // Archive
    fi.Refresh();
    Console.WriteLine("Refreshed attributes: {0}",fi.Attributes);// Archive, ReadOnly
