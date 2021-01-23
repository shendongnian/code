    using (MidiOut midiOut = new MidiOut(0))
    {
        midiOut.Send(MidiMessage.StartNote(60, 127, 0).RawData);
        Thread.Sleep(1000);
        midiOut.Send(MidiMessage.StopNote(60, 0, 0).RawData);
        Thread.Sleep(1000);
    }
