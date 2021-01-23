	using UnityEngine;
	using System.Collections;
	public class CharacterController : MonoBehaviour {
		
		public Vector2 maximumSpeed = new Vector2(1.0f, 1.0f);
		
		void Start() {
			
		}
		void Update() {
			Rigidbody rigidbody = GetComponent<Rigidbody>();
			
			Vector2 velocity = new Vector2();
			
			velocity.x = Input.GetAxis("Horizontal") * maximumSpeed.x;
			velocity.y = Input.GetAxis("Vertical") * maximumSpeed.y;
			
			rigidbody.velocity = velocity;
		}
		
	}
