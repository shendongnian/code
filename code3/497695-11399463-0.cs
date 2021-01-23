    //Add an application manifest using mt.exe
    System.Diagnostics.Process process = new System.Diagnostics.Process();
    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
    startInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
    startInfo.FileName = Path.Combine( System.Web.HttpContext.Current.Server.MapPath( "~/Content/" ), "mt.exe" );
    string AppManifestPath = Path.Combine( System.Web.HttpContext.Current.Server.MapPath( "~/Content/" ), "CustomInstaller.exe.manifest" );
    startInfo.Arguments = string.Format( "-nologo -manifest \"{0}\" -outputresource:\"{1};#1\"", AppManifestPath, cp.OutputAssembly );
    process.StartInfo = startInfo;
    process.Start();
    process.WaitForExit( 10000 ); //wait until finished (up to 10 sec)
