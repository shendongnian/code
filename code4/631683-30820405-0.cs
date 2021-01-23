        /// <summary>
        /// Delete the indicated application file
        /// </summary>
        /// <param name="strFilePathName">The file path name to delete</param>
        /// <returns>True, if successful; else false</returns>
        public async static Task<bool> DeleteAppFile(string strFilePathName)
        {
            try
            {
                StorageFile fDelete = null;
                if (!strFilePathName.Equals(""))
                {
                    fDelete = await ApplicationData.Current.LocalFolder.GetFileAsync(strFilePathName);
                    if (fDelete != null)
                    {
                        try
                        {
                            await fDelete.DeleteAsync();
                        }
                        catch (Exception ex)
                        {
                            AFFECTS.App.ShowMessage(true, "Error", "DeleteAppFile {" + strFilePathName + "}", ex.Message);
                            return false;
                        }
                        return true;
                    }
                }
                else
                    AFFECTS.App.ShowMessage(true, "Error", "DeleteAppFile", "File path name is empty.");
            }
            catch (Exception ex)
            {
                AFFECTS.App.ShowMessage(true, "Error", "DeleteAppFile {" + strFilePathName + "}", ex.Message);
            }
            return false;
        }
