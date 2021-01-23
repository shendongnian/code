    DynamicSoundEffectInstance generatedSound = new DynamicSoundEffectInstance(SampleRate, AudioChannels.Mono);
    generatedSound.SubmitBuffer(buffer);
    private void Int16ToTwoBytes(byte[] output, Int16 value, int offset)
    {
        output[offset + 1] = (byte)(value >> 8);
        output[offset] = (byte)(value & 0x00FF);
    }
