    using (var db = new ImageContext())
    {
        foreach (var file in files)
        {
            var sig = new ImageSignature
            {
                FileName = file,
                Signature = Signature(file),
            };
            Console.WriteLine("{0}: {1}", Path.GetFileName(sig.FileName), Sig2Str(sig.Signature));
            db.Images.Add(sig);
        }
        db.SaveChanges();
    }
