    private bool EnviarArchivoSFTP(string PuertoSFTP, string UrlFTP, string CarpetaFTP, string UsuarioFTP, string PasswordFTP, string FicheroFTP, string nombreArchivo)
    {
        bool archivoEnviado = false;
        using (var client = new SftpClient(UrlFTP, int.Parse(PuertoSFTP), UsuarioFTP, PasswordFTP))
        {
            client.ConnectionInfo.Timeout = TimeSpan.FromSeconds(1);
            client.OperationTimeout = TimeSpan.FromSeconds(1);
            client.Connect();
            client.ChangeDirectory(CarpetaFTP);
            string dataPath = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
            string appFile = Path.Combine(dataPath, FicheroFTP, nombreArchivo);//Se brindan permisos full sobre la carpeta
            using (var fileStream = new FileStream(appFile, FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            {
                client.BufferSize = 4 * 1024; // bypass Payload error large files
                client.UploadFile(fileStream, Path.GetFileName(nombreArchivo));
                archivoEnviado = true;
            }
        }
        return archivoEnviado;
    }
