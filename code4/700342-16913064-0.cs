       private usbListArrayDelegate mDeleg;
    
          protected override void WndProc(ref Message m)
          {
              int devType;
              base.WndProc(ref m);
              switch (m.WParam.ToInt32())
              {
                  case DBT_DEVICEARRIVAL:
                      devType = Marshal.ReadInt32(m.LParam, 4);
                      if (devType == DBT_DEVTYP_VOLUME)
                      {
                          // usb device inserted, call the query       
                          mDeleg = new usbListArrayDelegate(usbListArray);
                          AsyncCallback callback = new AsyncCallback(usbListArrayCallback);
                          // invoke the thread that will handle getting the friendly names   
                          mDeleg.BeginInvoke(callback, new object());   
                      }
                      
                      break;
                  
                  case DBT_DEVICEREMOVECOMPLETE:       
       
                      devType = Marshal.ReadInt32(m.LParam, 4);
                      if (devType == DBT_DEVTYP_VOLUME)
                      {
                          mDeleg = new usbListArrayDelegate(usbListArray);
                          AsyncCallback callback = new AsyncCallback(usbListArrayCallback);
                          // invoke the thread that will handle getting the friendly names   
                          mDeleg.BeginInvoke(callback, new object());   
                      }
                      
                      break;
             }
          }
          public ArrayList usbListArray()
          {
              ArrayList deviceList = new ArrayList();
               manager = new UsbManager();   ==> about how to implement this please see http://www.codeproject.com/Articles/63878/Enumerate-and-Auto-Detect-USB-Drives
              UsbDiskCollection disks = manager.GetAvailableDisks();
              foreach (UsbDisk disk in disks)
              {
                  deviceList.Add(disk);              
              }
              return deviceList;
          }   
          // delegate wrapper function for the getFriendlyNameList function   
          private delegate ArrayList usbListArrayDelegate();
          // callback method when the thread returns   
          private void usbListArrayCallback(IAsyncResult ar)
          {
              string ArrayData = string.Empty;
              // got the returned arrayList, now we can do whatever with it   
              ArrayList result = mDeleg.EndInvoke(ar);
              int count = 0;
              foreach (UsbDisk disk in result)
              {
                  ++count;
                  ArrayData += count + ") " + disk.ToString().
               }
  
