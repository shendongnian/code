        public String GetRealPathFromUri(Uri contentUri){
            String[] proj = {MediaStore.Audio.AudioColumns.Data};
            ICursor cursor = ManagedQuery(contentUri, proj, null, null, null);
            int column_index = cursor.GetColumnIndex(MediaStore.Audio.AudioColumns.Data);
            cursor.MoveToFirst();
            return cursor.GetString(column_index);
        }
    var responseRealPath = GetRealPathFromUri(responseUri);
    var getBytes = System.IO.File.ReadAllBytes(responseRealPath);
    var responseBase = Convert.ToBase64String(getBytes);
