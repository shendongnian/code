    SynAPICtrl1.Initialize
      SynAPICtrl1.Activate ' Activate to receive device notifications
      DeviceHandle = SynAPICtrl1.FindDevice(SE_ConnectionAny, SE_DevicecPad, -1)
      If DeviceHandle = -1 Then
        MsgBox "Unable to find a Synaptics cPad"
        End
      End If
            
      SynDeviceCtrl1.Select (DeviceHandle)
      SynDeviceCtrl1.Activate 'Activate to receive pointing packets
        
      ZTouchThreshold = SynDeviceCtrl1.GetLongProperty(SP_ZTouchThreshold)
