    wr.Write(Encoding.ASCII.GetBytes("RIFF"));
    wr.Write(0);
    wr.Write(Encoding.ASCII.GetBytes("WAVE"));
    wr.Write(Encoding.ASCII.GetBytes("fmt "));
    wr.Write(18 + (int)(numsamples * samplelength));
    wr.Write((short)1); // Encoding
    wr.Write((short)numchannels); // Channels
    wr.Write((int)(samplerate)); // Sample rate
    wr.Write((int)(samplerate * samplelength * numchannels)); // Average bytes per second
    wr.Write((short)(samplelength * numchannels)); // block align
    wr.Write((short)(8 * samplelength)); // bits per sample
    wr.Write((short)(numsamples * samplelength)); // Extra size
    wr.Write("data");
