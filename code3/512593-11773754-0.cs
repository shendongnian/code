    //Create a blob
    CloudBlob blob = new CloudBlob("newcontainer/ablob.text", blobClient);
    blob.UploadText("this is a blob");
    
    //Set CacheControl property
    blob.Properties.CacheControl = "public, max-age=31536000" // nocache is also an option;
    blob.SetProperties();
