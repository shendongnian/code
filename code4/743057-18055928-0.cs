    DefaultHttpClient mHttpClient = new DefaultHttpClient();  
    HttpGet mHttpGet = new HttpGet("your image url");  
    HttpResponse mHttpResponse = mHttpClient.execute(mHttpGet);  
    if (mHttpResponse.getStatusLine().getStatusCode() == HttpStatus.SC_OK) {  
        HttpEntity entity = mHttpResponse.getEntity();  
        if (entity != null) {  
        // insert to database  
        ContentValues values = new ContentValues();  
        values.put(MyBaseColumn.MyTable.ImageField, EntityUtils.toByteArray(entity));  
        getContentResolver().insert(MyBaseColumn.MyTable.CONTENT_URI, values);  
     }
    }
