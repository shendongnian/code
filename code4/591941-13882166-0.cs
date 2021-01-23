    using System.Collections.Generic;
    enum StarTypes { Black, White, Yellow, Red };
    abstract class Galaxy {
        Dictionary<StarTypes, float> _baseProbabilities;
        protected Galaxy() {
            _baseProbabilities = new Dictionary<StarTypes, float>();
            _baseProbabilities[StarTypes.Black] = 1.0f;
            _baseProbabilities[StarTypes.White] = 3.0f;
        }
        public float GetStarProbability(StarTypes starType) {
            return _baseProbabilities[starType] + GetStarProbabilityModifier(starType);
        }
        protected abstract float GetStarProbabilityModifier(StarTypes starType);
    }
    class YoungGalaxy : Galaxy {
        protected override float GetStarProbabilityModifier(StarTypes starType) {
            switch (starType) {
            case StarTypes.White:
                return 3.0f;
            default:
                return 0;
            }
        }
    }
