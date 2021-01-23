    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    using Emgu.Util;
    using Emgu.CV;
    using Emgu.CV.Structure;
    
    namespace HLSLTest
    {
        public delegate void Disp();
    
        /// <summary>
        /// This is the main type for your game
        /// </summary>
        public class Game1 : Microsoft.Xna.Framework.Game
        {
            Capture cap = new Capture("output.avi");
            GraphicsDeviceManager graphics;
            SpriteBatch spriteBatch;
    
            RenderTarget2D renOutput;
    
            Vector4[] gpuStore = new Vector4[1920 * 1080];
    
            Effect effect;
            QuadRender quad;
            public Game1()
            {
                graphics = new GraphicsDeviceManager(this);
                Content.RootDirectory = "Content";
            }
    
            /// <summary>
            /// Allows the game to perform any initialization it needs to before starting to run.
            /// This is where it can query for any required services and load any non-graphic
            /// related content.  Calling base.Initialize will enumerate through any components
            /// and initialize them as well.
            /// </summary>
            protected override void Initialize()
            {
                // TODO: Add your initialization logic here
    
                base.Initialize();
            }
    
            /// <summary>
            /// LoadContent will be called once per game and is the place to load
            /// all of your content.
            /// </summary>
            protected override void LoadContent()
            {
                // Create a new SpriteBatch, which can be used to draw textures.
                spriteBatch = new SpriteBatch(GraphicsDevice);
                quad = new QuadRender(GraphicsDevice);
    
                renOutput = new RenderTarget2D(GraphicsDevice, 1920, 1080, false, SurfaceFormat.Vector4, DepthFormat.Depth24);
    
                effect = Content.Load<Effect>("Shader");
    
                base.LoadContent();
    
                // TODO: use this.Content to load your game content here
            }
    
            /// <summary>
            /// UnloadContent will be called once per game and is the place to unload
            /// all content.
            /// </summary>
            protected override void UnloadContent()
            {
                // TODO: Unload any non ContentManager content here
            }
    
            /// <summary>
            /// Allows the game to run logic such as updating the world,
            /// checking for collisions, gathering input, and playing audio.
            /// </summary>
            /// <param name="gameTime">Provides a snapshot of timing values.</param>
            protected override void Update(GameTime gameTime)
            {
                // Allows the game to exit
                if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                    this.Exit();
    
                // TODO: Add your update logic here
    
                base.Update(gameTime);
            }
    
            /// <summary>
            /// This is called when the game should draw itself.
            /// </summary>
            /// <param name="gameTime">Provides a snapshot of timing values.</param>
            protected override void Draw(GameTime gameTime)
            {
                Image<Bgr, Byte> video = cap.QueryFrame();
                using (Image<Bgra, float> vid2 = video.Convert<Bgra, float>())
                {
    
                    Texture2D t = new Texture2D(GraphicsDevice, video.Width, video.Height, false, SurfaceFormat.Vector4);
                    t.SetData<byte>(vid2.Bytes);
    
                    GraphicsDevice.SetRenderTarget(renOutput);
                    effect.Parameters["Input0"].SetValue(t);
                    quad.RenderFullScreenQuad(effect);
                    for (int i = 0; i < effect.Techniques.Count; i++)
                    {
                        for (int j = 0; j < effect.Techniques[i].Passes.Count; j++)
                        {
                            effect.Techniques[i].Passes[j].Apply();
                        }
                    }
    
                    GraphicsDevice.SetRenderTarget(null);
                    renOutput.GetData<Vector4>(gpuStore);
                }
    
                base.Draw(gameTime);
            }
        }
    }
----
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Audio;
    using Microsoft.Xna.Framework.Content;
    using Microsoft.Xna.Framework.GamerServices;
    using Microsoft.Xna.Framework.Graphics;
    using Microsoft.Xna.Framework.Input;
    using Microsoft.Xna.Framework.Media;
    
    namespace HLSLTest
    {
        internal sealed class QuadRender
        {
            private VertexPositionTexture[] verts;
            private GraphicsDevice myDevice;
            private short[] ib = null;
    
            ///
            /// Loads the quad.
            ///
            ///
            public QuadRender(GraphicsDevice device)
            {
                myDevice = device;         
                verts = new VertexPositionTexture[]
                {
                    new VertexPositionTexture
                    (
                        new Vector3(0,0,0),
                        new Vector2(1,1)
                    ),
                    new VertexPositionTexture
                    (
                        new Vector3(0,0,0),
                        new Vector2(0,1)
                    ),
                    new VertexPositionTexture
                    (
                        new Vector3(0,0,0),
                        new Vector2(0,0)
                    ),
                    new VertexPositionTexture
                    (
                        new Vector3(0,0,0),
                        new Vector2(1,0)
                    )
                };
    
                ib = new short[] { 0, 1, 2, 2, 3, 0 };
            }             
    
            ///
            /// Draws the fullscreen quad.
            ///
            ///
            public void RenderFullScreenQuad(Effect effect)
            {
                effect.CurrentTechnique.Passes[0].Apply();
                RenderQuad(Vector2.One * -1, Vector2.One);
            }
    
            public void RenderQuad(Vector2 v1, Vector2 v2)
            {          
    
                verts[0].Position.X = v2.X;
                verts[0].Position.Y = v1.Y;
    
                verts[1].Position.X = v1.X;
                verts[1].Position.Y = v1.Y;
    
                verts[2].Position.X = v1.X;
                verts[2].Position.Y = v2.Y;
    
                verts[3].Position.X = v2.X;
                verts[3].Position.Y = v2.Y;
    
                myDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, verts, 0, 4, ib, 0, 2);
            }
        }
    }
