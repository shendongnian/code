            Symbol.Audio.Device MyDevice = (Symbol.Audio.Device)Symbol.StandardForms.SelectDevice.Select(
                Symbol.Audio.Controller.Title,
                Symbol.Audio.Device.AvailableDevices);
            Symbol.Audio.StandardAudio MyAudioDevice = new Symbol.Audio.StandardAudio(MyDevice);
            // set the volume of the audio from the settings file.
            MyAudioDevice.BeeperVolume = NewLevel;
            // set the audio device to nothing
            MyAudioDevice.Dispose();
            MyAudioDevice = null;
            MyDevice = null;
