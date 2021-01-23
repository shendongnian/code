    const double G = 6.67398 * 0.00000000001;
    for (int i = 0; i < particles.Count(); i++)
    {
        double sumX = 0;
        double sumY = 0;
        for (int j = 0; j < particles.Count(); j++)
        {
            // Don't add attraction to self
            if (i == j)
                continue;
            double distanceX = particles[i].Position.X - particles[j].Position.X;
            double distanceY = particles[i].Position.Y - particles[j].Position.Y;
            double r = Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));
            double force = G * particles[i].Mass * particles[j].Mass / (r * r);
            double theta = Math.Tan(distanceY / distanceX);
            sumX += force * Math.Cos(theta);
            sumY += force * Math.Sin(theta);
        }
        double netForce = Math.Sqrt(Math.Pow(sumX, 2) + Math.Pow(sumY, 2));
        double a = netForce / particles[i].Mass;
        double aTheta = Math.Tan(sumY / sumX);
        // Here we get accelerations for X and Y.  You can probably figure out velocities from here.
        double aX = a * Math.Cos(aTheta);
        double aY = a * Math.Sin(aTheta);
    }
