    try
    {
        //Comment this line out your handling it in the outside task already
        //postTask.Wait(client.Timeout); //Don't wait longer than the client timeout.
        success = postTask.Result.IsSuccessStatusCode;
     }catch {}
