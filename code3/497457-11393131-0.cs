    public void VerifyValue(String strObject, String strValue, int row)
    {               
         //strObject.ToUpper().Trim();
         //strValue.ToUpper().Trim();
         if(strObject.ToUpper() ==  "TASK_STATUS")
         {
              if (m_taskStatus.taskStatus.ToString() == strValue.ToUpper())
              {
                  ExcelRecorder(null, row);
              }
              else
              {
                   ExcelRecorder("The value [" + m_taskStatus.taskStatus.ToString() + "] does not match with the given value.", row);
               }
           }
    }
