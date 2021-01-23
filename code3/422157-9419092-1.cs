    public class InputPollingHandler
    {
        private QSGame game;
        /// <summary>
        /// Stores all <see cref="Keys"/> that are specifically listened for.
        /// </summary>
        private Dictionary<Keys, InputButton> keys;
        /// <summary>
        /// Create an instance of an input polling handler
        /// </summary>
        /// <param name="Game"></param>
        public InputPollingHandler(QSGame Game)
        {
            this.game = Game;
            this.keys = new Dictionary<Keys, InputButton>();           
            this.game.GameMessage += this.Game_GameMessage;
        }
        /// <summary>
        /// Add an input listener for a keyboard key.
        /// </summary>
        /// <param name="keyType">Key to listen for</param>
        public void AddInputListener(Keys keyType)
        {
            InputButton newButton = new InputButton();
            this.keys.Add(keyType, newButton);
        }
        /// <summary>
        /// Acquire a keyboard key
        /// </summary>
        /// <param name="keyType">Key to acquire</param>
        /// <param name="buttonRequested">Returns the <see cref="InputButton"/> requested</param>
        /// <returns>True if that button was registered for listening</returns>
        private bool ButtonFromType(Keys keyType, out InputButton buttonRequested)
        {
            return this.keys.TryGetValue(keyType, out buttonRequested);
        }
        /// <summary>
        /// Check if a keyboard key is currently being held
        /// </summary>
        /// <param name="keyType">Key to check</param>
        /// <returns>True if button is being held</returns>
        public bool IsHeld(Keys keyType)
        {
            InputButton buttonRequested;
            if (ButtonFromType(keyType, out buttonRequested))
            {
                return buttonRequested.IsHeld;
            }
            else
            {
                // This should be converted to an error that doesn't break like an exception does.
                throw new Exception("This key does not have a listener. It must have a listener before it can be used.");
                //return false;
            }
        }
        /// <summary>
        /// Check if a keyboard key is in the down state (was just pressed down).
        /// </summary>
        /// <param name="keyType">Keyboard key to check</param>
        /// <returns>True if key has just been pressed down</returns>
        public bool IsDown(Keys keyType)
        {
            InputButton buttonRequested;
            if (ButtonFromType(keyType, out buttonRequested))
            {
                return buttonRequested.IsDown;
            }
            else
            {
                // This should be converted to an error that doesn't break like an exception does.
                throw new Exception("This key does not have a listener. It must have a listener before it can be used.");
            }
        }
        /// <summary>
        /// Check if a keyboard key is in the up state (not pressed down or held).
        /// </summary>
        /// <param name="keyType">Keyboard key to check</param>
        /// <returns>True if button is up</returns>
        public bool IsUp(Keys keyType)
        {
            InputButton buttonRequested;
            if (ButtonFromType(keyType, out buttonRequested))
            {
                return buttonRequested.IsUp;
            }
            else
            {
                // This should be converted to an error that doesn't break like an exception does.
                throw new Exception("This key does not have a listener. It must have a listener before it can be used.");
                //return false;
            }
        }
        /// <summary>
        /// Press down a keyboard key in the polling handler (not the actual key).
        /// </summary>
        /// <param name="keyType">Key to press</param>
        /// <returns>True if key has been registered with a listener</returns>
        /// <remarks>Private because only the message system should use this function</remarks>
        private bool Press(Keys keyType)
        {
            InputButton buttonRequested;
            if (ButtonFromType(keyType, out buttonRequested))
            {
                buttonRequested.Press();
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Release a keyboard key in the polling handler (not the actual gamepad button).
        /// </summary>
        /// <param name="keyType">Keyboard key to release</param>
        /// <returns>True if key has been registered with a listener.</returns>
        /// <remarks>Private because only the message system should use this function</remarks>
        private bool Release(Keys keyType)
        {
            InputButton buttonRequested;
            if (ButtonFromType(keyType, out buttonRequested))
            {
                buttonRequested.Release();
                buttonRequested.SetHeld(false);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Set the held state of this keyboard key in the polling handler. This occurs whenever a key is being held.
        /// </summary>
        /// <param name="keyType">Keyboard key to hold</param>
        /// <param name="heldState">True for 'held', false to 'unhold'</param>
        /// <returns>True if key has been registered with a listener</returns>
        private bool SetHeld(Keys keyType, bool heldState)
        {
            InputButton buttonRequested;
            if (ButtonFromType(keyType, out buttonRequested))
            {
                buttonRequested.SetHeld(heldState);
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary>
        /// Set the lockable state of this keyboard key in the polling handler. Locked keys do not repeat or report as 'held'.
        /// </summary>
        /// <param name="keyType">Keyboard key for which to set lockable state</param>
        /// <param name="lockableState">'true' will set this key to 'lockable'</param>
        /// <returns>True if this key has been registered with a listener</returns>
        public bool SetLockable(Keys keyType, bool lockableState)
        {
            InputButton buttonRequested;
            if (ButtonFromType(keyType, out buttonRequested))
            {
                buttonRequested.SetLockable(lockableState);
                return true;
            }
            else
            {
                // This should be converted to an error that doesn't break like an exception does.
                throw new Exception("This key does not have a listener. It must have a listener before it can be used.");
                //return false;
            }
        }
        /// <summary>
        /// Message handler for the input polling handler.
        /// </summary>
        /// <param name="message">Incoming message</param>
        private void Game_GameMessage(IMessage message)
        {
            switch (message.Type)
            {
                case MessageType.KeyDown:
                    MsgKeyPressed keyDownMessage = message as MsgKeyPressed;
                    message.TypeCheck(keyDownMessage);
                    Press(keyDownMessage.Key);
                    break;
                case MessageType.KeyUp:
                    MsgKeyReleased keyUpMessage = message as MsgKeyReleased;
                    message.TypeCheck(keyUpMessage);
                    Release(keyUpMessage.Key);
                    break;
                case MessageType.KeyHeld:
                    MsgKeyHeld keyPressMessage = message as MsgKeyHeld;
                    message.TypeCheck(keyPressMessage);
                    SetHeld(keyPressMessage.Key, true);
                    break;
            }
        }
    }
