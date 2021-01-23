    public class MyBehaviour : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            var collider = other.gameObject;
            // Do something...
            Debug.Log(collider);
        }
    }
