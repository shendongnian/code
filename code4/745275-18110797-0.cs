    class Buoyancy : MonoBehaviour {
        public float UpwardForce = 10.81f; // 9.81 is the opposite of the default gravity, which is 9.81. If we want the boat not to behave like a submarine the upward force has to be higher than the gravity in order to push the boat to the surface
        private bool isInWater = false;
        void OnTriggerStay(Collidier collidier) {
            if(collidier.gameObject.tag == "water") {
                // we are inside the water
                isInWater = true;
            } else {
                isInwater = false;
            }
        }
        void FixedUpdate() {
            if(isInwater) {
                // apply upward force
                this.rigidbody.AddForce(Vector.up * UpwardForce, ForceMode.Force);
            }
        }
    }
