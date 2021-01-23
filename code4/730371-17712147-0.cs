    class GameSoundManager {
        public SoundEffect PlayerDie { get; set; }
    }
    class Game {
        private GameSoundManager _soundManager;
        private Player _player;
        public Game() {
            _soundManager = new GameSoundManager() {
                PlayerDie = // load the sound
            };
            _player = new Player(_soundManager);
        }
    }
    class Player {
        private GameSoundManager _soundManager;
        public Player(GameSoundManager soundManager) {
            _soundManager = soundManager;
        }
        // use _soundManager.PlayerDie anywhere in your player class.
    }
