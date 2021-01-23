    public bool IsDiscAvailable(int driveNumber)
    {
        MsftDiscMaster2Class discMaster = new MsftDiscMaster2Class();
        string id = discMaster[driveNumber];
        MsftDiscRecorder2Class recorder = new MsftDiscRecorder2Class();
        recorder.InitializeDiscRecorder(id);
        MsftDiscFormat2DataClass dataWriter = new MsftDiscFormat2DataClass();
        if (dataWriter.IsRecorderSupported(recorder))
        {
            dataWriter.Recorder = recorder;
        }
        else
        {
            Console.WriteLine("Recorder not supported");
            return false;
        }
        if (dataWriter.IsCurrentMediaSupported(recorder))
        {
            var media = dataWriter.CurrentPhysicalMediaType;
            if (media == IMAPI_MEDIA_PHYSICAL_TYPE.IMAPI_MEDIA_TYPE_UNKNOWN)
            {
                Console.WriteLine("Unknown media or no disc");
            }
            else
            {
                Console.WriteLine("Found disc type {0}", media);
                return true;
            }
        }
        else
        {
            Console.WriteLine("Disc absent or invalid.");
        }
        return false;
    }
