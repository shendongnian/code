    Globals.DropBox.Token = AppLimit.CloudComputing.SharpBox.StorageProvider.DropBox.DropBoxStorageProviderTools
    .ExchangeDropBoxRequestTokenIntoAccessToken(
          Globals.DropBox.config
        , Globals.DropBox.AppKey, Globals.DropBox.AppSec
        , Globals.DropBox.requestToken
    );
                
