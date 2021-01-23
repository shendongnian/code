	using UnityEngine;
	using System.Collections;
	public class Audio_RanGen: MonoBehaviour {
		public AudioClip[] sounds;
		// Use this for initialization
		void Start() {
			sounds=Resources.LoadAll("YourSoundsFolder", typeof(AudioClip));
		}
		// Update is called once per frame
		void Update() {
		}
		void OnGUI() {
			if(GUI.Button(new Rect(100, 200, 200, 50), "Random Number Genaration")) {
				if(!audio.isPlaying) { 
					audio.clip=sound[Random.Range(0, sounds.Length)];
					audio.Play(); 
				}
			}
		}
	}
