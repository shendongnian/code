    public async Task<UploadResult> UploadFileToDir(string dir, string text)
    {
        try
        {
            await SftpClient.Cd(dir)
            var filename = await this.GetFilename();
            await SftpClient.WriteFile(filename, text);
            return UploadResult.Success;
        }
        catch(SshException ex)
        {
            return UploadResult.Failure;
        }
    }
