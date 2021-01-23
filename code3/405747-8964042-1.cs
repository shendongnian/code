    class KeyUpper
    {
        private readonly BufferBlock<Key> m_keyBuffer = new BufferBlock<Key>();
        public async Task RegisterEvaluator(
            Func<Func<Task<Key>>, Task<bool>> evaluate)
        {
            while (true)
            {
                if (await evaluate(m_keyBuffer.ReceiveAsync))
                    SomeResponse();
            }
        }
        public void KeyUp(object sender, KeyEventArgs e)
        {
            m_keyBuffer.Post(e.Key);
        }
        private void SomeResponse()
        {
            // whatever
        }
    }
