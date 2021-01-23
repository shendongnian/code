    using System.IO;
    using System.IO.IsolatedStorage;
    using System.Xml.Serialization;
    namespace PhoneApp1
    {
    public class IsolatedStorage
    {
        public static void SaveToIs(String fileName, Object saved)
        {
            try
            {
                using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isf.FileExists(fileName))
                    {
                        isf.DeleteFile(fileName);
                    }
                    using (IsolatedStorageFileStream fs = isf.CreateFile(fileName))
                    {
                        XmlSerializer ser = new XmlSerializer(saved.GetType());
                        ser.Serialize(fs, saved);
                    }
                }
            }
            catch (IsolatedStorageException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public static Object loadFromIS(String fileName, Type t)
        {
            Object result = null;
            try
            {
                using (IsolatedStorageFile isf = IsolatedStorageFile.GetUserStoreForApplication())
                {
                    if (isf.FileExists(fileName))
                    {
                        using (StreamReader sr = new StreamReader(isf.OpenFile(fileName, FileMode.Open)))
                        {
                            XmlSerializer ser = new XmlSerializer(t);
                            result = ser.Deserialize(sr);
                        }
                    }
                }
            }
            catch (IsolatedStorageException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException e)
            {
                MessageBox.Show(e.Message);
            }
            return result;
        }
    }
    }
