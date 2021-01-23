    using Melanchall.DryWetMidi.Devices;
    using Melanchall.DryWetMidi.Core;
    
    // ...
    
    var midiFile = MidiFile.Read("Background music.mid");
    // or from stream:
    // var midiFile = MidiFile.Read(stream);
    var outputDevice = OutputDevice.GetByName("MIDI device to play with");
    var playback = midiFile.GetPlayback(outputDevice);
    
    playback.Loop = true;
    playback.Start();
