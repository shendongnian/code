      var bytes = File.ReadAllBytes(@"C:\Bill\TestWaveFiles\14043.wav");
      MemoryStream packStream = new MemoryStream()
      Package pack = Package.Open(packStream, FileMode.Create, FileAccess.ReadWrite);
      Uri packUri = new Uri("bla:");
      PackageStore.AddPackage(packUri, pack);
      Uri packPartUri = new Uri("/MemoryResource", UriKind.Relative);
      PackagePart packPart = pack.CreatePart(packPartUri, "Media/MemoryResource");
      packPart.GetStream().Write(bytes, 0, bytes.Length);
      var inMemoryUri = PackUriHelper.Create(packUri, packPart.Uri);
      mediaElement1.LoadedBehavior = MediaState.Manual;
      mediaElement1.Source = inMemoryUri;
      mediaElement1.Play();
