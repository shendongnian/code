        public void RotL(float gametime)
        {
            rotAngle += (gametime * speed);
            rotAngle = rotAngle % CIRCLE_IN_DEGREES;
            rads = rotAngle * (Math.PI / 180);
            if (rotAngle <= MAX_ROT)
            {
                rotAngle = MAX_ROT;
                speed = 1.0F;
                Endpoint.X = (float)(PADDLE_WID * Math.Cos(MAX_RADS));
                Endpoint.Y = (float)(PADDLE_WID * Math.Sin(MAX_RADS));
            }
            else if (rotAngle >= INIT_ROT)
            {
                data manipulation that mirrors the previous if clause, replacing MAX_RADS with INIT_RADS
            }
            else
            {
                speed += 0.45F;
                Endpoint.X = (float)(PADDLE_WID * Math.Cos(rads));
                Endpoint.Y = (float)(PADDLE_WID * Math.Sin(rads));
            }
