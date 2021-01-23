    /// <summary>
    /// This class handles keyboard input
    /// </summary>
    public class KeyboardHandler : InputHandler
    {
        /// <summary>
        /// A list of keys that were down during the last update
        /// </summary>
        private List<KeyInfo> previousDownKeys;
        /// <summary>
        /// Holds the current keyboard state
        /// </summary>
        private KeyboardState currentKeyboardState;
        /// <summary>
        /// Creates a keyboard handler.
        /// </summary>
        /// <param name="game"></param>
        public KeyboardHandler(QSGame game)
            : base(game)
        {
            this.previousDownKeys = new List<KeyInfo>();
        }
        /// <summary>
        /// Reads the current keyboard state and processes all key messages required.
        /// </summary>
        /// <param name="gameTime"></param>
        /// <remarks>This process may seem complicated and unefficient, but honestly most keyboards can
        /// only process 4-6 keys at any given time, so the lists we're iterating through are relatively small.
        /// So at the most we're doing 42 comparisons if 6 keys can be held at time. 42 comparisons only if the
        /// 6 keys pressed during one frame are different than the 6 keys pressed on the next frame, which is
        /// extremely unlikely.</remarks>
        protected override void UpdateCore(GameTime gameTime)
        {
            this.currentKeyboardState = Keyboard.GetState();
            Keys[] currentlyPressed = this.currentKeyboardState.GetPressedKeys();
            bool[] isHeld = new bool[currentlyPressed.Length];
            for (int i = currentlyPressed.Length - 1; i >= 0; i--)
            {
                Keys key = currentlyPressed[i];
                // There were no keys down last frame, no need to loop through the last frame's state
                if (this.previousDownKeys.Count == 0)
                {
                    // Because no keys were down last frame, every key that is down this frame is newly pressed.
                    SendKeyMessage(MessageType.KeyDown, key, gameTime);
                }
                else
                {
                    bool processed = false;
                    // Loop through all the keys that were pressed last frame, for comparison
                    for (int j = this.previousDownKeys.Count - 1; j >= 0; j--)
                    {
                        // If this key was used at all last frame then it is being held
                        if (key == this.previousDownKeys[j].key)
                        {
                            // We should keep track of the timer for each index in an array large enough for all keys
                            // so we can have a timer for how long each key has been held. This can come later. Until
                            // then keys are marked as held after one frame. - LordIkon
                            if (this.previousDownKeys[j].heldLastFrame == false)
                            {
                                // Send held message
                                isHeld[i] = true;
                                SendKeyMessage(MessageType.KeyHeld, key, gameTime);
                            }
                            else
                            {
                                isHeld[i] = true;
                            }
                            previousDownKeys.Remove(this.previousDownKeys[j]);   // Remove this key from the previousDownKeys list
                            processed = true;
                            break;
                        }
                    }
                    // If key was un-processed throughout the loop, process message here as a new key press
                    if (processed == false)
                    {
                        SendKeyMessage(MessageType.KeyDown, key, gameTime);
                    }
                }
            }
            // If there any keys left in the previous state after comparisons, it means they were released
            if (this.previousDownKeys.Count > 0)
            {
                // Go through all keys and send 'key up' message for each one
                for (int i = this.previousDownKeys.Count - 1; i >= 0; i--)
                {
                    // Send released message
                    SendKeyMessage(MessageType.KeyUp, this.previousDownKeys[i].key, gameTime);
                }
            }
            this.previousDownKeys.Clear();      // Clear the previous list of keys down
            // Update the list of previous keys that are down for next loop
            for (int i = currentlyPressed.Length - 1; i >= 0; i--)
            {
                Keys key = currentlyPressed[i];
                KeyInfo newKeyInfo;
                newKeyInfo.key = key;
                newKeyInfo.heldLastFrame = isHeld[i];
                this.previousDownKeys.Add(newKeyInfo);
            }
        }
        /// <summary>
        /// Sends a message containing information about a specific key
        /// </summary>
        /// <param name="keyState">The state of the key Down/Pressed/Up</param>
        /// <param name="key">The <see cref="Keys"/> that changed it's state</param>
        private void SendKeyMessage(MessageType keyState, Keys key, GameTime gameTime)
        {
            switch (keyState)
            {
                case MessageType.KeyDown:
                    {
                        MsgKeyPressed keyMessage = ObjectPool.Aquire<MsgKeyPressed>();
                        keyMessage.Key = key;
                        keyMessage.Time = gameTime;
                        this.Game.SendMessage(keyMessage);
                    }
                    break;
                case MessageType.KeyHeld:
                    {
                        MsgKeyHeld keyMessage = ObjectPool.Aquire<MsgKeyHeld>();
                        keyMessage.Key = key;
                        keyMessage.Time = gameTime;
                        this.Game.SendMessage(keyMessage);
                    }
                    break;
                case MessageType.KeyUp:
                    {
                        MsgKeyReleased keyMessage = ObjectPool.Aquire<MsgKeyReleased>();
                        keyMessage.Key = key;
                        keyMessage.Time = gameTime;
                        this.Game.SendMessage(keyMessage);
                    }
                    break;
                default:
                    break;
            }
            
        }
    }
