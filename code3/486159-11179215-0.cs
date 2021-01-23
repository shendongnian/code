    using UnityEngine;
    using System.Collections;
    public class MovingSphere : Monobehavior // Attatch to sphere1
    {
        public GameObject sphere1, sphere2; // Set these in the inspector
        // Say sphere1 is at (-2, 0, 0)
        // Say sphere2 is at ( 0, 0, 0)
        void Update( )
        {
            if(sphere2.transform.position.x < 5) // If x-position of sphere2 < 5
            {
                sphere1.transform.Translate(0.1f, 0, 0); // Moves the first sphere
            }                                            // positively on the x-plane
        }
    }
