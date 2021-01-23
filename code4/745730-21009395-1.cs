     using (Doc copyDoc = new Doc())
          {
               copyDoc.Read(filePath);
               copyDoc.RemapPages(sb.ToString());
               copyDoc.Save(tagetFileName);
          }
