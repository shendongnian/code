    Utilities.WaitSharingVio(
        action: () =>
        {
            using (var f = File.Open(file, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.None))
            {
                // ... blah, process the file
            }
        },
        onSharingVio: () =>
        {
            Console.WriteLine("Sharing violation. Trying again soon...");
        }
    );
